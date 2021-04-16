namespace Model3D
{
    public struct Matrix4x4
    {
        public double V00;
        public double V01;
        public double V02;
        public double V03;
        public double V10;
        public double V11;
        public double V12;
        public double V13;
        public double V20;
        public double V21;
        public double V22;
        public double V23;
        public double V30;
        public double V31;
        public double V32;
        public double V33;

        private static Matrix4x4 CreateIdentityMatrix()
        {
            Matrix4x4 m = new Matrix4x4();
            m.V00 = m.V11 = m.V22 = m.V33 = 1;
            return m;
        }

        public static Matrix4x4 CreateScale(double scale)
        {
            var m = new Matrix4x4();
            m.V00 = m.V11 = m.V22 = scale;
            m.V33 = 1f;

            return m;
        }


        public static Matrix4x4 CreateRotationY(double radians)
        {
            Matrix4x4 m = CreateIdentityMatrix();

            double cos = (double)System.Math.Cos(radians);
            double sin = (double)System.Math.Sin(radians);

            m.V00 = m.V22 = cos;
            m.V02 = sin;
            m.V20 = -sin;

            return m;
        }

        public static Matrix4x4 CreateRotationX(double radians)
        {
            Matrix4x4 m = CreateIdentityMatrix();

            double cos = (double)System.Math.Cos(radians);
            double sin = (double)System.Math.Sin(radians);

            m.V11 = m.V22 = cos;
            m.V12 = -sin;
            m.V21 = sin;

            return m;
        }

        public static Matrix4x4 CreateRotationZ(double radians)
        {
            Matrix4x4 m = CreateIdentityMatrix();

            double cos = (double)System.Math.Cos(radians);
            double sin = (double)System.Math.Sin(radians);

            m.V00 = m.V11 = cos;
            m.V01 = -sin;
            m.V10 = sin;

            return m;
        }

        public static Matrix4x4 CreateFromYawPitchRoll(double yaw, double pitch, double roll)
        {
            return (CreateRotationY(yaw) * CreateRotationX(pitch)) * CreateRotationZ(roll);
        }

        public static Matrix4x4 CreateTranslation(Point3D position)
        {
            Matrix4x4 m = CreateIdentityMatrix();

            m.V03 = position.X;
            m.V13 = position.Y;
            m.V23 = position.Z;

            return m;
        }


        public static Matrix4x4 operator *(Matrix4x4 matrix1, Matrix4x4 matrix2)
        {
            Matrix4x4 m = new Matrix4x4
            {
                V00 = matrix1.V00 * matrix2.V00 + matrix1.V01 * matrix2.V10 + matrix1.V02 * matrix2.V20 + matrix1.V03 * matrix2.V30,
                V01 = matrix1.V00 * matrix2.V01 + matrix1.V01 * matrix2.V11 + matrix1.V02 * matrix2.V21 + matrix1.V03 * matrix2.V31,
                V02 = matrix1.V00 * matrix2.V02 + matrix1.V01 * matrix2.V12 + matrix1.V02 * matrix2.V22 + matrix1.V03 * matrix2.V32,
                V03 = matrix1.V00 * matrix2.V03 + matrix1.V01 * matrix2.V13 + matrix1.V02 * matrix2.V23 + matrix1.V03 * matrix2.V33,

                V10 = matrix1.V10 * matrix2.V00 + matrix1.V11 * matrix2.V10 + matrix1.V12 * matrix2.V20 + matrix1.V13 * matrix2.V30,
                V11 = matrix1.V10 * matrix2.V01 + matrix1.V11 * matrix2.V11 + matrix1.V12 * matrix2.V21 + matrix1.V13 * matrix2.V31,
                V12 = matrix1.V10 * matrix2.V02 + matrix1.V11 * matrix2.V12 + matrix1.V12 * matrix2.V22 + matrix1.V13 * matrix2.V32,
                V13 = matrix1.V10 * matrix2.V03 + matrix1.V11 * matrix2.V13 + matrix1.V12 * matrix2.V23 + matrix1.V13 * matrix2.V33,

                V20 = matrix1.V20 * matrix2.V00 + matrix1.V21 * matrix2.V10 + matrix1.V22 * matrix2.V20 + matrix1.V23 * matrix2.V30,
                V21 = matrix1.V20 * matrix2.V01 + matrix1.V21 * matrix2.V11 + matrix1.V22 * matrix2.V21 + matrix1.V23 * matrix2.V31,
                V22 = matrix1.V20 * matrix2.V02 + matrix1.V21 * matrix2.V12 + matrix1.V22 * matrix2.V22 + matrix1.V23 * matrix2.V32,
                V23 = matrix1.V20 * matrix2.V03 + matrix1.V21 * matrix2.V13 + matrix1.V22 * matrix2.V23 + matrix1.V23 * matrix2.V33,

                V30 = matrix1.V30 * matrix2.V00 + matrix1.V31 * matrix2.V10 + matrix1.V32 * matrix2.V20 + matrix1.V33 * matrix2.V30,
                V31 = matrix1.V30 * matrix2.V01 + matrix1.V31 * matrix2.V11 + matrix1.V32 * matrix2.V21 + matrix1.V33 * matrix2.V31,
                V32 = matrix1.V30 * matrix2.V02 + matrix1.V31 * matrix2.V12 + matrix1.V32 * matrix2.V22 + matrix1.V33 * matrix2.V32,
                V33 = matrix1.V30 * matrix2.V03 + matrix1.V31 * matrix2.V13 + matrix1.V32 * matrix2.V23 + matrix1.V33 * matrix2.V33
            };

            return m;
        }

        public static Point3D operator *(Matrix4x4 matrix, Point3D vector)
        {
            return new Point3D(
                matrix.V00 * vector.X + matrix.V01 * vector.Y + matrix.V02 * vector.Z,
                matrix.V10 * vector.X + matrix.V11 * vector.Y + matrix.V12 * vector.Z,
                matrix.V20 * vector.X + matrix.V21 * vector.Y + matrix.V22 * vector.Z
                );
        }
    }
}
