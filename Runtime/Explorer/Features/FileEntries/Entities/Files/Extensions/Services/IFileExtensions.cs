﻿using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Extensions
{
    internal interface IFileExtensions
    {
        AudioType GetAudioType(string extension);
        bool IsText(string extension);
        bool IsImage(string extension);
        bool IsAudio(string extension);
    }
}