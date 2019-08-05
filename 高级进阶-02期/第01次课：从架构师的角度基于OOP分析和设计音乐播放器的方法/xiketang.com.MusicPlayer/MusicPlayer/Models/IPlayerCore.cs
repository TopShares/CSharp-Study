using System.Collections.Generic;

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
    /// 播放器核心接口
    /// </summary>
    public interface IPlayerCore
    {
        /// <summary>
        /// 播放的文件列表
        /// </summary>
        Dictionary<string, PlayedFile> FileList { get; set; }

        /// <summary>
        /// 播放模式
        /// </summary>
        string PlayMode { get; set; }
             

        /// <summary>
        /// 从文件读取最新播放列表
        /// </summary>
        /// <returns>返回读取是否成功</returns>
        bool LoadNewList();

        /// <summary>
        /// 保存最新的播放列表到文件
        /// </summary>
        void SaveNewList();

        /// <summary>
        /// 读取上一次播放位置（其实是播放第几个文件位置）
        /// </summary>
        /// <returns></returns>
        int ReadPlayIndex();   
        /// <summary>
        /// 保存播放位置
        /// </summary>
        /// <param name="index"></param>
        void SavePlayIndex(int index);

        /// <summary>
        /// 清空播放列表
        /// </summary>
        void ClearPlayList();

        /// <summary>
        /// 文件另存为
        /// </summary>
        /// <param name="newDirectory"></param>
        void SaveFileAs(string newDirectory);

    }
}