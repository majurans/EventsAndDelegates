using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video { Title = "Video Title" };

            VideoEncoder encoder = new VideoEncoder(); // Publisher
            MailService mailService = new MailService(); // Subscriber
            MessageService messageService = new MessageService();
            encoder.VideoEncoded += mailService.OnVideoEncoded;
            encoder.VideoEncoded += messageService.OnVideoEncoded;

            encoder.Encode(video);

        }

    }

    class MailService
    {
        public void OnVideoEncoded(object sender, VideoEventArgs e)
        {
            Console.WriteLine("Mail service sending an email: " + e.Video.Title);
        }
    }

    class MessageService
    {
        public void OnVideoEncoded(object sender, VideoEventArgs e)
        {
            Console.WriteLine("Message service sending text message: " + e.Video.Title);
        }
    }
}
