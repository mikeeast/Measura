using System;
using System.Net;

namespace Measura
{
    public class ItemUserVisit
    {
        public ItemUserVisit(int itemId, IPAddress ipAddress, DateTime dateTime)
        {
            ItemId = itemId;
            IpAddress = ipAddress;
            DateTime = dateTime;
        }

        public int ItemId { get; set; }
        public IPAddress IpAddress { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", ItemId, IpAddress, DateTime);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = ItemId;
                hashCode = (hashCode*397) ^ (IpAddress != null ? IpAddress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ DateTime.GetHashCode();
                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ItemUserVisit) obj);
        }

        bool Equals(ItemUserVisit other)
        {
            return ItemId == other.ItemId && Equals(IpAddress, other.IpAddress);
        }
    }
}
