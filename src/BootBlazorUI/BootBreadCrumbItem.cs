﻿using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现面包屑导航的 li 元素。
    /// </summary>
    public class BootBreadCrumbItem : BootComponentBase
    {
        /// <summary>
        /// 级联的 <see cref="BootBreadCrumb"/> 对象。
        /// </summary>
        [CascadingParameter] BootBreadCrumb CascadingBreadCrumb { get; set; }

        /// <summary>
        /// 设置导航元素里的标题。若设置了 <see cref="ChildContent"/> 的内容，则该属性的值将被忽略。
        /// </summary>
        [Parameter] public string Title { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否为启用状态。
        /// </summary>
        [Parameter] public bool Active { get; set; }

        /// <summary>
        /// 设置超链接的地址。
        /// </summary>
        [Parameter] public string Link { get; set; }

        /// <summary>
        /// 设置呈现组件内部的任意内容。若设置，则 <see cref="Title"/> 的值将被忽略。
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="BootChildNotInParentComponentException{BootBreadCrumb, BootBreadCrumbItem}"></exception>
        protected override void OnInitialized()
        {
            if (CascadingBreadCrumb == null)
            {
                throw new BootChildNotInParentComponentException<BootBreadCrumb, BootBreadCrumbItem>();
            }
            CascadingBreadCrumb.Add(this);
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "li");
            AddCommonAttributes(builder);
            if (!string.IsNullOrWhiteSpace(Link))
            {
                builder.OpenElement(1, "a");
                builder.AddAttribute(2, "href", Link);
                BuildContent(builder, 3);
                builder.CloseElement();
            }
            else
            {
                BuildContent(builder, 1);
            }
            builder.CloseElement();
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="collection">css 类名称集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("breadcrumb-item");
            if (Active)
            {
                collection.Add("active");
            }
        }

        /// <summary>
        /// 构造 Title 或 ChildContent 属性。
        /// </summary>
        /// <param name="builder"><see cref="RenderTreeBuilder"/> 实例。</param>
        /// <param name="sequence">序列。</param>
        void BuildContent(RenderTreeBuilder builder, int sequence)
        {
            if (ChildContent == null)
            {
                builder.AddContent(sequence, Title);
            }
            else
            {
                builder.AddContent(sequence, ChildContent);
            }
        }
    }
}
