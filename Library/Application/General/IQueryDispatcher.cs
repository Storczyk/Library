﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.General
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
