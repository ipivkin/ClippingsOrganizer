using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loading
{
    public class LoadingClass
    {
        private Form _activeForm, _loadingForm;

        public LoadingClass(Form activeForm, Form loadingForm)
        {
            _activeForm = activeForm;
            _loadingForm = loadingForm;
        }

        public void loading_thread()
        {
            _loadingForm.Location = new Point(
                (_activeForm.Location.X + _activeForm.Width / 2) - (_loadingForm.Width / 2),
                (_activeForm.Location.Y + _activeForm.Height / 2) - (_loadingForm.Height / 2));
            _loadingForm.StartPosition = FormStartPosition.Manual;
            _loadingForm.ShowDialog();
        }
    }
}
