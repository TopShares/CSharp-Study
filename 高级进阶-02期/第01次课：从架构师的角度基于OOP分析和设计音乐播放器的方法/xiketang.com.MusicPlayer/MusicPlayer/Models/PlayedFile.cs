using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer
{
    /// <summary>
    /// 喜科堂互联教育网址：xiketang.ke.qq.com
    /// 原创设计：常慧勇    QQ：2934008878
    /// 版权声明：版权所有，侵权必究。本项目源码是开放式设计，不能用于任何商业用途！
    /// 如有更改，请标注哪些更改！
    /// 本课程地址：https://ke.qq.com/course/248962
    /// </summary>
    /// <summary>
    /// 播放的视频文件实体类
    /// </summary>
    [Serializable]
    public class PlayedFile
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 播放时长(double类型)
        /// </summary>
        public double PlayedTotalTime { get; set; }

        /// <summary>
        /// 播放时长（字符串表示）
        /// </summary>
        public string PlayedTotalTimeString { get; set; }
      
    }
}
