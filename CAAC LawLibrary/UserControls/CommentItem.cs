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

namespace CAAC_LawLibrary.UserControls
{
    public partial class CommentItem : UserControl
    {
        public Comment comment;

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
    }
}
