using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSingleton
{
    //Delegate_Event
    //B1: Xay dung lop su kien.. dan xuat tu lop su kien
    //su kien click se bi click
    public class ClickEvent : EventArgs
    {
        private string message;
        public string MESSAGE
        {
            get { return message; }
        }
        //constructor
        public ClickEvent(string message)
        {
            this.message = message;
        }
    }
    //B2: Doi tuong nhan su kien
    //Publisher class
    public class Button
    {
        string caption;
        public string CAPTION
        {
            get
            {
                return caption;
            }
        }
        //constructor
        public Button(string caption)
        {
            this.caption = caption;
        }
        //delegate & event, delegate phuc vu cho nhieu event
        //Xu ly click event handle
        //2 thanh phan : object va su kien
        //(object sender,EventArgs e)
        public delegate void ClickEventHandler(Button bt, ClickEvent ec);
        //thu ly viec click
        public event ClickEventHandler OnClick;
        //notify thong bao da bi click
        public void CLicked()
        {
            // tao 1 su kien moi Su kien

            ClickEvent ce = new ClickEvent("Button was clicked!!!");
            //goi thang thu li den
            if (OnClick != null)
            {
                OnClick(this, ce);
            }
        }
    }
    //Cung cap hanh vi dap ung su kien
    //Suncriber class
    //Lop cung cap hanh vi dap ung su kien
    public class ClickHandler
    {
        //constructor
        public ClickHandler(Button bt)
        {
            bt.OnClick += new Button.ClickEventHandler(Action1);
        }
        //neu su kien xay ra nguoi di xu ly la Action1
        public void Action1(Button bt, ClickEvent ec)
        {
            Console.WriteLine("Button {0}: {1}!!!!", bt.CAPTION,ec.MESSAGE);
        }
    }
    public class Event
    {
        public static void Test()
        {
            Button bt1 = new Button("OK");
            ClickHandler bt1Click = new ClickHandler(bt1);
            //...
            //...
            bt1.CLicked();

            Console.ReadKey();
        }
    }
}
