using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }

    }

    class VideoEncoder
    {
        //1 - Define a delegate (Method signature for the subscriber method, event handler should conform this delegate signature)
        public delegate void VideoEncodedEventHandler(object sender, VideoEventArgs e);

        //Instead of defining a custom delegate written above we can use .NET built in delegate for declaring events
        //EventHander & EventHandler<TEventArgs> delegates


        //2 - Define an event based on the delegate
        public event VideoEncodedEventHandler VideoEncoded;

        public event EventHandler VideoEncoded2;
        //or
        public event EventHandler<VideoEventArgs> VideoEncoded3;


        //3 - Raise the event

        public void Encode(Video video)
        {
            Console.WriteLine("Video Encoding");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }

        //Event rasiser signature should be protected virtual void
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs { Video = video });
        }
    }
}
