using DynamicDll.Db;
using System.Data.SqlClient;

namespace TaskRun.Models.Entity {
    public class CommentDAO : BaseDao<CommentEntity> {
        public override int Delete(CommentEntity entity) {
            throw new NotImplementedException();
        }

        public override CommentDTO Find(params object[] pkeys) {
        string query = @"
            SELECT 
                t1.id AS user_id,
                t2.id AS task_id,
                t3.id,
                t3.update_datetime,
                t1.password,
                t1.user_name,
                t2.task_name,
                t3.comment,
                t2.memo
            FROM 
                m_user t1
            LEFT JOIN 
                t_task t2 ON t1.id = t2.user_id
            LEFT JOIN 
                t_comment t3 ON t1.id = t3.user_id
            WHERE 
                t3.id = @Id";

            CommentDTO comm = new CommentDTO();
            using (SqlCommand cmd = new SqlCommand(query, con)) {
                cmd.Transaction = trn;

                cmd.Parameters.Add("@Id", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@Id"].Value = pkeys[0].ToString();

                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        comm.Id = int.Parse(reader["id"].ToString());
                        comm.UserId = int.Parse(reader["user_id"].ToString());
                        comm.TaskId = int.Parse(reader["task_id"].ToString());
                        comm.Comment = reader["comment"].ToString();
                        comm.UpdateDateTime = DateTime.Parse(reader["update_datetime"].ToString());
                        comm.TaskName = reader["task_name"].ToString();
                        comm.UserName = reader["user_name"].ToString();
                    }
                    reader.Close();
                }
            }
            return comm;
        }

        public override int Insert(CommentEntity entity) {
            throw new NotImplementedException();
        }

        public override int Update(CommentEntity entity) {
            throw new NotImplementedException();
        }
        //public List<CommentEntity> FindAll(int taskId) {
        //    string query = "SELECT * FROM t_comment where task_id = @id;";
        //    using (SqlCommand cmd = new SqlCommand(query, con)) {
        //        cmd.Transaction = trn;

        //        using (SqlDataReader reader = cmd.ExecuteReader()) {
        //            while (reader.Read()) {
        //                CommentEntity ce = new CommentEntity();

        //            }
    }
}
