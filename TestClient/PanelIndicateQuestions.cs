using System;

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
    public class PanelIndicateQuestions
    {
        public Panel Panel { set; get; }
        public Point Location { set; get; }
        public int Height { set; get; }
        public int Width { set; get; }
        public int Count { get { return Buttons.Count; } }

        const int PADDING = 3;

        const int SPACE = 3;

        public List<Button> Buttons { set; get; } = new List<Button>();
        public PanelIndicateQuestions(Panel panelForm, int countButtons, int constCount)
        {
            if (countButtons <= 0) throw new Exception("countButtons <= 0 !");
            this.Panel = panelForm;
            this.Location = panelForm.Location;
            this.Height = panelForm.Height;
            this.Width = panelForm.Width;

            int locationX = Location.X ;
            int locationY = Location.Y ;
            int height = Height - PADDING * 2;
            int width = Width - PADDING * 2;

            int heightButton = height - 2;
            int widthButton = (width - SPACE * (countButtons)) / constCount;

            for (int i = 0; i < countButtons; i++)
            {
                Button button = new Button();
                button.Tag = i;
                button.Location = new Point(locationX + (widthButton+SPACE)*i, locationY);
                button.Size = new Size(widthButton, heightButton);
                button.BackColor = Color.Red;
                button.Padding = new Padding(0);
                button.Margin = new Padding(0);
                Buttons.Add(button);
                panelForm.Controls.Add(button);
            }
        }
        
        public void InitButtons(Panel panelForm, int countButtons)
        {
            if (countButtons <= 0 || panelForm == null) return;

            

        }

    }
}
