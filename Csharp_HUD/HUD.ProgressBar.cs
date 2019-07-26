using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Csharp_HUD
{
    public partial class HUD
    {
        #region Define ProgressBar
        /// <summary>
        /// Define the brush and its thickness to draw progress bar
        /// </summary>
        private readonly Brush BRUSH = new SolidColorBrush(Color.FromArgb(255, 255, 180, 51));
        private readonly double THICKNESS = 2;
        /// <summary>
        /// Define the default animation time
        /// </summary>
        private Duration DURATION = new Duration(new TimeSpan(0, 0, 0, 0, 600));
        /// <summary>
        ///  progress bar, include 5 Line and 4 Corners
        ///                                     ┌→Start
        /// corner[3]┌─ line[4] ─ ☆  ─ line[0] ─┐corner[0]
        ///                │                                        │
        ///              line[3]                                line[1]
        ///                │                                        │
        /// corner[2]└───── line[2] ──────┘corner[1]
        /// </summary>
        private Line[] line = new Line[5];
        private PathFigure[] corner = new PathFigure[4]; // 存放corner的ArcSegment
        /// <summary>
        /// 1th dim: which line
        /// 2th dim: start or end of line
        /// 3th dim: x or y coordinate
        /// </summary>
        private int[,,] line_point =
        {
            { {70, 5}, {130, 5} },
            { {135, 10}, {135, 140} },
            { {130, 145}, {10, 145} },
            { {5, 140}, {5, 10} },
            { {10, 5}, {70, 5} }
        };
        #endregion

        #region Create ProgressBar
        /// <summary>
        /// Draw the line partial of progress bar
        /// </summary>
        private void DrawLine()
        {
            for (int lineNum = 0; lineNum < line.Length; lineNum++)
            {
                line[lineNum] = new Line();
                line[lineNum].Stroke = BRUSH;
                line[lineNum].StrokeThickness = THICKNESS;
                line[lineNum].X1 = line_point[lineNum, 0, 0];
                line[lineNum].Y1 = line_point[lineNum, 0, 1];
                line[lineNum].X2 = line_point[lineNum, 1, 0];
                line[lineNum].Y2 = line_point[lineNum, 1, 1];
                cv_canvas.Children.Add(line[lineNum]);
            }
        }
        /// <summary>
        /// Draw the corner partial of progress bar
        /// Canvas Layer: Canves -> Path -> PathGeometry -> PathFigure -> ArcSegment
        /// </summary>
        private void DrawCorner()
        {
            PathGeometry pathGeometry = new PathGeometry(); // TO store figure
            for (int cornerNum = 0; cornerNum < corner.Length; cornerNum++)
            {
                ArcSegment arcSegment = new ArcSegment();
                arcSegment.Size = new Size(5, 5);    // 設定x, y方向之圓半徑
                arcSegment.SweepDirection = SweepDirection.Clockwise;   // 設定順時針畫Arc
                arcSegment.Point = new Point(line_point[cornerNum + 1, 0, 0], line_point[cornerNum + 1, 0, 1]); // 角落圓弧終點(下一條線的起點)
                corner[cornerNum] = new PathFigure();
                corner[cornerNum].StartPoint = new Point(line_point[cornerNum, 1, 0], line_point[cornerNum, 1, 1]); // 角落圓弧起點(這條線的終點)
                corner[cornerNum].Segments.Add(arcSegment);
                pathGeometry.Figures.Add(corner[cornerNum]);
            }
            Path path = new Path();
            path.Stroke = BRUSH;
            path.StrokeThickness = THICKNESS;
            path.Data = pathGeometry;
            cv_canvas.Children.Add(path);
        }
        private void DrawProgressBar()
        {
            DrawLine();
            DrawCorner();
        }
        #endregion

        #region Set ProgressBar Animation
        /// <summary>
        /// Set the animation of line (By Recursive)
        /// </summary>
        /// <param name="lineNum"></param>
        /// <param name="cornerNum"></param>
        /// <returns></returns>
        private Storyboard SetDurationAnimation(int lineNum, int cornerNum)
        {
            Storyboard storyBoard = new Storyboard();
            DoubleAnimation daX = new DoubleAnimation(line[lineNum].X1, line[lineNum].X2, DURATION);
            DoubleAnimation daY = new DoubleAnimation(line[lineNum].Y1, line[lineNum].Y2, DURATION);
            Storyboard.SetTargetProperty(daX, new PropertyPath("(Line.X1)"));
            Storyboard.SetTargetProperty(daY, new PropertyPath("(Line.Y1)"));
            storyBoard.Children.Add(daX);
            storyBoard.Children.Add(daY);
            if (cornerNum < corner.Length) storyBoard.Completed += (s, e) => corner[cornerNum].Segments.Clear();
            if (lineNum + 1 < line.Length) storyBoard.Completed += (s, e) => line[lineNum + 1].BeginStoryboard(SetDurationAnimation(lineNum + 1, cornerNum + 1));
            else if (lineNum + 1 == line.Length) storyBoard.Completed += (s, e) => this.Close();
            return storyBoard;
        }
        #endregion
    }
}
