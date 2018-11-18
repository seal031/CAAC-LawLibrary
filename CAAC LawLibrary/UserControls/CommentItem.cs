using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;

namespace CAAC_LawLibrary.UserControls
{
    public partial class CommentItem : UserControl
    {
        public Comment comment;
        public LawView lawView;

        public CommentItem()
        {
            InitializeComponent();
        }

        public void fillContent()
        {
            lbl_node.Text = comment.nodeName;
            lbl_content.Text = comment.comment_content;
            lbl_user.Text = comment.userName + " " + comment.department + " " + comment.comment_date;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Global.online == false)
            {
                MessageBox.Show("离线状态无法发表评论");
            }
            else
            {
                AddNewComment addComment = new CAAC_LawLibrary.AddNewComment();
                addComment.lawId = comment.lawId;
                addComment.nodeId = comment.nodeId;
                addComment.lawView = lawView;
                addComment.Show(this);
            }
        }
    }
}
