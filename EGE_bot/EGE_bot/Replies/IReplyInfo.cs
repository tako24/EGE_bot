using System;
using System.Collections.Generic;

namespace EGE_bot
{
    public interface IReplyInfo<T>
	{
         string Text { get; set; }
         public T Keyboard { get; set;}

       // T CreateMarkup(List<string> buttons);
    }
}
