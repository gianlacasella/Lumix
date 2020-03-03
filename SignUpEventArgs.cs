using System;

namespace Entrega2_Equipo1
{
    public class SignUpEventArgs : EventArgs
    {
        string usrname;
        string password;

        public string Usrname { get => this.usrname; set => this.usrname = value; }
        public string Password { get => this.password; set => this.password = value; }
    }
}
