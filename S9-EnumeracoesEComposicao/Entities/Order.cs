using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S9_EnumeracoesEComposicao.Entities.Enums;
using System.Globalization;

namespace S9_EnumeracoesEComposicao.Entities
{
    class Order
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(int id, DateTime moment, OrderStatus status)
        {
            Id = id;
            Moment = moment;
            Status = status;
        }

        public Order(int id, DateTime moment, OrderStatus status, Client client)
        {
            Id = id;
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            OrderItems.Remove(item);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrderItem item in OrderItems)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Resumo do Pedido:");
            sb.AppendLine();
            sb.Append("Data do pedido: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Cliente: ");
            sb.AppendLine(Client.ToString());
            sb.AppendLine();
            sb.AppendLine("Itens inclusos: ");
            foreach (OrderItem item in OrderItems)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine();
            sb.Append("Preço Total: $");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
