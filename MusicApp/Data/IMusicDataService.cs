﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Model;

namespace MusicApp.Data
{
    public interface IMusicDataService
    {
        Task<Album> GetByIdAsync(int albumId);
        Task SaveAsync(Album album);
    }
}
