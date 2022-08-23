using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    //Trta oos argumentos para o evento StatusChanged
    public class StatusChagedEventsArgs:EventArgs
    {
        //Estamos interessados na mensagem descrevendo o evento
        private string EventMsg;

        //Propriedade para retornar e definir uma mensagem

        public string EventMessage
        {
            get { return EventMsg; }
            set { EventMsg = value; }
        }

        //Construtor para definir a mensagem do evento
        public StatusChagedEventsArgs(string strEventMsg)
        {
            EventMsg = strEventMsg;
        }
    }
}
