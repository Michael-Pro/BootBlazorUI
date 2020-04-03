﻿using System;
using System.Collections.Generic;
using System.Text;
using BootBlazorUI.Dialog;
using Microsoft.Extensions.DependencyInjection;

namespace BootBlazorUI
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 添加对话框的服务。
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection AddDialog(this IServiceCollection services, Action<DialogConfiguration> configure = default)
        {
            services.AddScoped<IDialogService, DialogService>();

            var instance = new DialogConfiguration();
            if (configure == null)
            {
                configure = (e) => e = instance;
            }
            configure.Invoke(instance);
            services.Configure(configure);
            return services;
        }
    }
}