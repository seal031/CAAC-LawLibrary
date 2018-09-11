using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;
using CAAC_LawLibrary.BLL.Entity;
using CAAC_LawLibrary.BLL;

namespace CAAC_LawLibrary
{
    public partial class AddNewComment : Form
    {
        public string title;
        public string lawId;
        public string nodeId;

        public AddNewComment()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            Comment newComment = new Comment();
            newComment.lawId = lawId;
            newComment.nodeId = nodeId;
            newComment.comment_content = rtb_content.Text.Trim();
            newComment.comment_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            newComment.userId = Global.user.Id;

            OpinionCommitRequest opinionRequest = new OpinionCommitRequest();
            opinionRequest.ConvertFromComment(newComment);
            //RemoteWorker
            RemoteWorker.postOpinion(opinionRequest);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
