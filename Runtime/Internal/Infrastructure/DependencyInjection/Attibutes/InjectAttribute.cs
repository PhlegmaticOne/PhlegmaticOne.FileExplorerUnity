using System;
using UnityEngine.Scripting;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class InjectAttribute : PreserveAttribute { }
}