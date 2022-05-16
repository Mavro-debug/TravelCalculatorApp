using MileageKilometersTravelCalculatorApp.Domein.Interfaces;
using MileageKilometersTravelCalculatorApp.Domein.Models;

namespace MileageKilometersTravelCalculatorApp.Service
{
    public class TimeCommentDeterminator : ITimeCommentDeterminator
    {
        public string DererminateCommentForTime(Time time)
        => time switch
        {
            { Hours: 0, Minutes: 0 } => "You will reach your destination in literally no time",
            { Hours: int h, Minutes: int m } when h * 60 + m > 0 && h * 60 + m < 40 => "No need to prepare, you will be on the site in on time",
            { Hours: int h, Minutes: int m } when h * 60 + m >= 40 && h * 60 + m < 60 => "This is not a long ride but it is always good to have a nice mixtape with you",
            { Hours: int h, Minutes: int m } when h * 60 + m >= 60 && h * 60 + m < 120 => "This is some ride. It is always a good idea to prepare a solid mixtape with you",
            { Hours: int h, Minutes: int m } when h * 60 + m >= 120 && h * 60 + m < 240 => "This is a long ride! There are some great podcasts to be found on the Internet",
            { Hours: int h, Minutes: int m } when h * 60 + m >= 240 && h * 60 + m < 360 => "This is a long ride!!! Podcasts, mixtapes and coffee, that is the way to go",
            { Hours: int h, Minutes: int m } when h * 60 + m >= 360 => "This is a long ride!!! I think you should buy an ebook for the occasion",
            _ => throw new Exception()
        };
    }
}
