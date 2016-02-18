using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDPAdmin
{
    //public class EventInfo
    //{
    //    public string ID { get; set; }
    //    public string EVENT_NAME { get; set; }
    //    public string EVENT_INFO { get; set; }
    //    public string EVENT_DATETIME { get; set; }
    //    public string EVENT_ATTACHMENT { get; set; }
    //    public string EVENT_TARGET_TYPE { get; set; }
    //    public string EVENT_TARGET { get; set; }
    //    public string DATETIME { get; set; }
    //}

    //public class ImageInfo
    //{
    //    public string ID { get; set; }
    //    public string IMAGE_HEADER { get; set; }
    //    public string IMAGE_TITLE { get; set; }
    //    public string IMAGE_ATTACHMENT { get; set; }
    //    public string IMAGE_TARGET { get; set; }
    //    public string DATETIME { get; set; }
    //}

    //public class VideoInfo
    //{
    //    public string ID { get; set; }
    //    public string VIDEO_HEADER { get; set; }
    //    public string VIDEO_TITLE { get; set; }
    //    public string VIDEO_URL { get; set; }
    //    public string DATETIME { get; set; }
    //}

    //public class Quote
    //{
    //    public string ID { get; set; }
    //    public string QUOTE { get; set; }
    //    public string DATETIME { get; set; }
    //}

    public class Donation
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
    }

    public class DonationDetail
    {
        public string DonationID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gotram { get; set; }
        public string DateOn { get; set; }
        public string TotalAmount { get; set; }
        public string Nakshatram { get; set; }
        public string PhoneNumber { get; set; }
    }


    public class DonationMember
    {
        public string SNO { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Nakshatram { get; set; }

    }
}