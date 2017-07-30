using System;
using System.Collections.Generic;
using System.Text;

namespace WSCME.Domain.Enum
{
    /// <summary>
    /// 考场计划状态
    /// </summary>
    public enum ExamRoomPlantState
    {
        /// <summary>
        /// 默认状态 也是计划创建后的默认状态
        /// </summary>
        Default,
        /// <summary>
        /// 场次等待选择
        /// </summary>
        Selecting,
        /// <summary>
        /// 场次结束选择
        /// </summary>
        EndSelect,
        /// <summary>
        /// 开始签到
        /// </summary>
        SignIn,
        /// <summary>
        /// 场次正在考试
        /// </summary>
        Examing,
        /// <summary>
        /// 场次已经结束
        /// </summary>
        Over
    }
}
