using System;

namespace EGE_bot
{
    public interface IReplyInfo<T>
	{
         string Name { get; set; }
         string Text { get; set; }
         public T Keyboard { get; set;}
    }
}
