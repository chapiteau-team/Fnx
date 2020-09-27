using System;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    public partial interface IApply<TF>
    {
        IKind<TF, TZ> Ap3<TA1, TA2, TA3, TZ>(IKind<TF, Func<TA1, TA2, TA3, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3) =>
            Ap(Ap2(Map<Func<TA1, TA2, TA3, TZ>, Func<TA1, TA2, Func<TA3, TZ>>>(
                ff, f => (a1, a2) => a3 => f(a1, a2, a3)), fa1, fa2), fa3);

        IKind<TF, TZ> Ap4<TA1, TA2, TA3, TA4, TZ>(IKind<TF, Func<TA1, TA2, TA3, TA4, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4) =>
            Ap2(
                Ap2(
                    Map<Func<TA1, TA2, TA3, TA4, TZ>, Func<TA1, TA2, Func<TA3, TA4, TZ>>>(
                        ff, f => (a1, a2) => (a3, a4) => f(a1, a2, a3, a4)
                    ), fa1, fa2
                ), fa3, fa4
            );

        IKind<TF, TZ> Ap5<TA1, TA2, TA3, TA4, TA5, TZ>(IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5) =>
            Ap2(
                Ap3(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TZ>, Func<TA1, TA2, TA3, Func<TA4, TA5, TZ>>>(
                        ff,
                        f => (a1, a2, a3) => (a4, a5) => f(a1, a2, a3, a4, a5)
                    ), fa1, fa2, fa3
                ), fa4, fa5
            );

        IKind<TF, TZ> Ap6<TA1, TA2, TA3, TA4, TA5, TA6, TZ>(IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6) =>
            Ap3(
                Ap3(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TZ>, Func<TA1, TA2, TA3, Func<TA4, TA5, TA6, TZ>>>(
                        ff,
                        f => (a1, a2, a3) => (a4, a5, a6) => f(a1, a2, a3, a4, a5, a6)
                    ), fa1, fa2, fa3
                ), fa4, fa5, fa6
            );

        IKind<TF, TZ> Ap7<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7) =>
            Ap3(
                Ap4(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TZ>,
                        Func<TA1, TA2, TA3, TA4, Func<TA5, TA6, TA7, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4) => (a5, a6, a7) => f(a1, a2, a3, a4, a5, a6, a7)
                    ), fa1, fa2, fa3, fa4
                ), fa5, fa6, fa7
            );

        IKind<TF, TZ> Ap8<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8) =>
            Ap4(
                Ap4(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TZ>,
                        Func<TA1, TA2, TA3, TA4, Func<TA5, TA6, TA7, TA8, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4) => (a5, a6, a7, a8) => f(a1, a2, a3, a4, a5, a6, a7, a8)
                    ), fa1, fa2, fa3, fa4
                ), fa5, fa6, fa7, fa8
            );

        IKind<TF, TZ> Ap9<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9) =>
            Ap4(
                Ap5(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TZ>,
                        Func<TA1, TA2, TA3, TA4, TA5, Func<TA6, TA7, TA8, TA9, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4, a5) => (a6, a7, a8, a9) => f(a1, a2, a3, a4, a5, a6, a7, a8, a9)
                    ), fa1, fa2, fa3, fa4, fa5
                ), fa6, fa7, fa8, fa9
            );

        IKind<TF, TZ> Ap10<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10) =>
            Ap5(
                Ap5(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TZ>,
                        Func<TA1, TA2, TA3, TA4, TA5, Func<TA6, TA7, TA8, TA9, TA10, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4, a5) => (a6, a7, a8, a9, a10) => f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10)
                    ), fa1, fa2, fa3, fa4, fa5
                ), fa6, fa7, fa8, fa9, fa10
            );

        IKind<TF, TZ> Ap11<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11) =>
            Ap5(
                Ap6(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TZ>,
                        Func<TA1, TA2, TA3, TA4, TA5, TA6, Func<TA7, TA8, TA9, TA10, TA11, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4, a5, a6) => (a7, a8, a9, a10, a11) =>
                            f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11)
                    ), fa1, fa2, fa3, fa4, fa5, fa6
                ), fa7, fa8, fa9, fa10, fa11
            );

        IKind<TF, TZ> Ap12<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12) =>
            Ap6(
                Ap6(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TZ>,
                        Func<TA1, TA2, TA3, TA4, TA5, TA6, Func<TA7, TA8, TA9, TA10, TA11, TA12, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4, a5, a6) => (a7, a8, a9, a10, a11, a12) =>
                            f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12)
                    ), fa1, fa2, fa3, fa4, fa5, fa6
                ), fa7, fa8, fa9, fa10, fa11, fa12
            );

        IKind<TF, TZ> Ap13<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13) =>
            Ap6(
                Ap7(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TZ>,
                        Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, Func<TA8, TA9, TA10, TA11, TA12, TA13, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4, a5, a6, a7) => (a8, a9, a10, a11, a12, a13) =>
                            f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13)
                    ), fa1, fa2, fa3, fa4, fa5, fa6, fa7
                ), fa8, fa9, fa10, fa11, fa12, fa13
            );

        IKind<TF, TZ> Ap14<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13, IKind<TF, TA14> fa14) =>
            Ap7(
                Ap7(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TZ>,
                        Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, Func<TA8, TA9, TA10, TA11, TA12, TA13, TA14, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4, a5, a6, a7) => (a8, a9, a10, a11, a12, a13, a14) =>
                            f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14)
                    ), fa1, fa2, fa3, fa4, fa5, fa6, fa7
                ), fa8, fa9, fa10, fa11, fa12, fa13, fa14
            );

        IKind<TF, TZ> Ap15<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TZ>> ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13, IKind<TF, TA14> fa14,
            IKind<TF, TA15> fa15) =>
            Ap7(
                Ap8(
                    Map<Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TZ>,
                        Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8,
                            Func<TA9, TA10, TA11, TA12, TA13, TA14, TA15, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4, a5, a6, a7, a8) => (a9, a10, a11, a12, a13, a14, a15) =>
                            f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15)
                    ), fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8
                ), fa9, fa10, fa11, fa12, fa13, fa14, fa15
            );

        IKind<TF, TZ> Ap16<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TA16, TZ>(
            IKind<TF, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TA16, TZ>>
                ff,
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13, IKind<TF, TA14> fa14,
            IKind<TF, TA15> fa15, IKind<TF, TA16> fa16) =>
            Ap8(
                Ap8(
                    Map<
                        Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TA16, TZ>,
                        Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8,
                            Func<TA9, TA10, TA11, TA12, TA13, TA14, TA15, TA16, TZ>>>(
                        ff,
                        f => (a1, a2, a3, a4, a5, a6, a7, a8) => (a9, a10, a11, a12, a13, a14, a15, a16) =>
                            f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16)
                    ), fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8
                ), fa9, fa10, fa11, fa12, fa13, fa14, fa15, fa16
            );

        IKind<TF, TZ> Map3<TA1, TA2, TA3, TZ>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3,
            Func<TA1, TA2, TA3, TZ> f) =>
            Ap(
                Map2<TA1, TA2, Func<TA3, TZ>>(fa1, fa2, (a1, a2) => a3 => f(a1, a2, a3)),
                fa3
            );

        IKind<TF, TZ> Map4<TA1, TA2, TA3, TA4, TZ>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3,
            IKind<TF, TA4> fa4, Func<TA1, TA2, TA3, TA4, TZ> f) =>
            Ap2(
                Map2<TA1, TA2, Func<TA3, TA4, TZ>>(fa1, fa2, (a1, a2) => (a3, a4) => f(a1, a2, a3, a4)),
                fa3, fa4
            );

        IKind<TF, TZ> Map5<TA1, TA2, TA3, TA4, TA5, TZ>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3,
            IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, Func<TA1, TA2, TA3, TA4, TA5, TZ> f) =>
            Ap2(
                Map3<TA1, TA2, TA3, Func<TA4, TA5, TZ>>(fa1, fa2, fa3,
                    (a1, a2, a3) => (a4, a5) => f(a1, a2, a3, a4, a5)),
                fa4, fa5
            );

        IKind<TF, TZ> Map6<TA1, TA2, TA3, TA4, TA5, TA6, TZ>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3,
            IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6, Func<TA1, TA2, TA3, TA4, TA5, TA6, TZ> f) =>
            Ap3(
                Map3<TA1, TA2, TA3, Func<TA4, TA5, TA6, TZ>>(fa1, fa2, fa3,
                    (a1, a2, a3) => (a4, a5, a6) => f(a1, a2, a3, a4, a5, a6)),
                fa4, fa5, fa6
            );

        IKind<TF, TZ> Map7<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TZ>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2,
            IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6, IKind<TF, TA7> fa7,
            Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TZ> f) =>
            Ap3(
                Map4<TA1, TA2, TA3, TA4, Func<TA5, TA6, TA7, TZ>>(fa1, fa2, fa3, fa4,
                    (a1, a2, a3, a4) => (a5, a6, a7) => f(a1, a2, a3, a4, a5, a6, a7)),
                fa5, fa6, fa7
            );

        IKind<TF, TZ> Map8<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TZ>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2,
            IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6, IKind<TF, TA7> fa7,
            IKind<TF, TA8> fa8, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TZ> f) =>
            Ap4(
                Map4<TA1, TA2, TA3, TA4, Func<TA5, TA6, TA7, TA8, TZ>>(fa1, fa2, fa3, fa4,
                    (a1, a2, a3, a4) => (a5, a6, a7, a8) => f(a1, a2, a3, a4, a5, a6, a7, a8)),
                fa5, fa6, fa7, fa8
            );

        IKind<TF, TZ> Map9<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TZ>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2,
            IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6, IKind<TF, TA7> fa7,
            IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TZ> f) =>
            Ap4(
                Map5<TA1, TA2, TA3, TA4, TA5, Func<TA6, TA7, TA8, TA9, TZ>>(fa1, fa2, fa3, fa4, fa5,
                    (a1, a2, a3, a4, a5) => (a6, a7, a8, a9) => f(a1, a2, a3, a4, a5, a6, a7, a8, a9)),
                fa6, fa7, fa8, fa9
            );

        IKind<TF, TZ> Map10<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TZ>(IKind<TF, TA1> fa1,
            IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6,
            IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TZ> f) =>
            Ap5(
                Map5<TA1, TA2, TA3, TA4, TA5, Func<TA6, TA7, TA8, TA9, TA10, TZ>>(fa1, fa2, fa3, fa4, fa5,
                    (a1, a2, a3, a4, a5) => (a6, a7, a8, a9, a10) => f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10)),
                fa6, fa7, fa8, fa9, fa10
            );

        IKind<TF, TZ> Map11<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TZ>(IKind<TF, TA1> fa1,
            IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6,
            IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10, IKind<TF, TA11> fa11,
            Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TZ> f) =>
            Ap5(
                Map6<TA1, TA2, TA3, TA4, TA5, TA6, Func<TA7, TA8, TA9, TA10, TA11, TZ>>(fa1, fa2, fa3, fa4, fa5, fa6,
                    (a1, a2, a3, a4, a5, a6) =>
                        (a7, a8, a9, a10, a11) => f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11)),
                fa7, fa8, fa9, fa10, fa11
            );

        IKind<TF, TZ> Map12<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TZ>(IKind<TF, TA1> fa1,
            IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6,
            IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10, IKind<TF, TA11> fa11,
            IKind<TF, TA12> fa12, Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TZ> f) =>
            Ap6(
                Map6<TA1, TA2, TA3, TA4, TA5, TA6, Func<TA7, TA8, TA9, TA10, TA11, TA12, TZ>>(
                    fa1, fa2, fa3, fa4, fa5, fa6,
                    (a1, a2, a3, a4, a5, a6) => (a7, a8, a9, a10, a11, a12) =>
                        f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12)),
                fa7, fa8, fa9, fa10, fa11, fa12
            );

        IKind<TF, TZ> Map13<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TZ>(IKind<TF, TA1> fa1,
            IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6,
            IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10, IKind<TF, TA11> fa11,
            IKind<TF, TA12> fa12, IKind<TF, TA13> fa13,
            Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TZ> f) =>
            Ap6(
                Map7<TA1, TA2, TA3, TA4, TA5, TA6, TA7, Func<TA8, TA9, TA10, TA11, TA12, TA13, TZ>>(
                    fa1, fa2, fa3, fa4, fa5, fa6, fa7,
                    (a1, a2, a3, a4, a5, a6, a7) =>
                        (a8, a9, a10, a11, a12, a13) => f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13)),
                fa8, fa9, fa10, fa11, fa12, fa13
            );

        IKind<TF, TZ> Map14<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TZ>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13, IKind<TF, TA14> fa14,
            Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TZ> f) =>
            Ap7(
                Map7<TA1, TA2, TA3, TA4, TA5, TA6, TA7, Func<TA8, TA9, TA10, TA11, TA12, TA13, TA14, TZ>>(
                    fa1, fa2, fa3, fa4, fa5, fa6, fa7,
                    (a1, a2, a3, a4, a5, a6, a7) =>
                        (a8, a9, a10, a11, a12, a13, a14) =>
                            f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14)),
                fa8, fa9, fa10, fa11, fa12, fa13, fa14
            );

        IKind<TF, TZ> Map15<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TZ>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13, IKind<TF, TA14> fa14,
            IKind<TF, TA15> fa15,
            Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TZ> f) =>
            Ap7(
                Map8<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, Func<TA9, TA10, TA11, TA12, TA13, TA14, TA15, TZ>>(
                    fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8,
                    (a1, a2, a3, a4, a5, a6, a7, a8) =>
                        (a9, a10, a11, a12, a13, a14, a15) =>
                            f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15)),
                fa9, fa10, fa11, fa12, fa13, fa14, fa15
            );

        IKind<TF, TZ> Map16<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TA16, TZ>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13, IKind<TF, TA14> fa14,
            IKind<TF, TA15> fa15, IKind<TF, TA16> fa16,
            Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TA16, TZ> f) =>
            Ap8(
                Map8<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, Func<TA9, TA10, TA11, TA12, TA13, TA14, TA15, TA16, TZ>>(
                    fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8,
                    (a1, a2, a3, a4, a5, a6, a7, a8) =>
                        (a9, a10, a11, a12, a13, a14, a15, a16) =>
                            f(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16)),
                fa9, fa10, fa11, fa12, fa13, fa14, fa15, fa16
            );

        IKind<TF, (TA1, TA2, TA3)> Tuple3<TA1, TA2, TA3>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3) =>
            Map3(fa1, fa2, fa3, (a1, a2, a3) => (a1, a2, a3));

        IKind<TF, (TA1, TA2, TA3, TA4)> Tuple4<TA1, TA2, TA3, TA4>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2,
            IKind<TF, TA3> fa3, IKind<TF, TA4> fa4) =>
            Map4(fa1, fa2, fa3, fa4, (a1, a2, a3, a4) => (a1, a2, a3, a4));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5)> Tuple5<TA1, TA2, TA3, TA4, TA5>(IKind<TF, TA1> fa1, IKind<TF, TA2> fa2,
            IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5) =>
            Map5(fa1, fa2, fa3, fa4, fa5, (a1, a2, a3, a4, a5) => (a1, a2, a3, a4, a5));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6)> Tuple6<TA1, TA2, TA3, TA4, TA5, TA6>(IKind<TF, TA1> fa1,
            IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6) =>
            Map6(fa1, fa2, fa3, fa4, fa5, fa6, (a1, a2, a3, a4, a5, a6) => (a1, a2, a3, a4, a5, a6));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7)> Tuple7<TA1, TA2, TA3, TA4, TA5, TA6, TA7>(IKind<TF, TA1> fa1,
            IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5, IKind<TF, TA6> fa6,
            IKind<TF, TA7> fa7) =>
            Map7(fa1, fa2, fa3, fa4, fa5, fa6, fa7, (a1, a2, a3, a4, a5, a6, a7) => (a1, a2, a3, a4, a5, a6, a7));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8)> Tuple8<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8) =>
            Map8(fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8,
                (a1, a2, a3, a4, a5, a6, a7, a8) => (a1, a2, a3, a4, a5, a6, a7, a8));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9)> Tuple9<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9) =>
            Map9(fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8, fa9,
                (a1, a2, a3, a4, a5, a6, a7, a8, a9) => (a1, a2, a3, a4, a5, a6, a7, a8, a9));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10)> Tuple10<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8,
            TA9, TA10>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10) =>
            Map10(fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8, fa9, fa10,
                (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11)> Tuple11<TA1, TA2, TA3, TA4, TA5, TA6, TA7,
            TA8,
            TA9, TA10, TA11>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11) =>
            Map11(fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8, fa9, fa10, fa11,
                (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12)> Tuple12<TA1, TA2, TA3, TA4, TA5, TA6,
            TA7, TA8, TA9, TA10, TA11, TA12>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12) =>
            Map12(fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8, fa9, fa10, fa11, fa12,
                (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12) =>
                    (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13)> Tuple13<TA1, TA2, TA3, TA4,
            TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13) =>
            Map13(fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8, fa9, fa10, fa11, fa12, fa13,
                (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13) =>
                    (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14)> Tuple14<TA1, TA2, TA3,
            TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13, IKind<TF, TA14> fa14) =>
            Map14(fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8, fa9, fa10, fa11, fa12, fa13, fa14,
                (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14) =>
                    (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15)> Tuple15<TA1, TA2,
            TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13, IKind<TF, TA14> fa14,
            IKind<TF, TA15> fa15) =>
            Map15(fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8, fa9, fa10, fa11, fa12, fa13, fa14, fa15,
                (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15) =>
                    (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15));

        IKind<TF, (TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TA16)> Tuple16<TA1,
            TA2, TA3, TA4, TA5, TA6, TA7, TA8, TA9, TA10, TA11, TA12, TA13, TA14, TA15, TA16>(
            IKind<TF, TA1> fa1, IKind<TF, TA2> fa2, IKind<TF, TA3> fa3, IKind<TF, TA4> fa4, IKind<TF, TA5> fa5,
            IKind<TF, TA6> fa6, IKind<TF, TA7> fa7, IKind<TF, TA8> fa8, IKind<TF, TA9> fa9, IKind<TF, TA10> fa10,
            IKind<TF, TA11> fa11, IKind<TF, TA12> fa12, IKind<TF, TA13> fa13, IKind<TF, TA14> fa14,
            IKind<TF, TA15> fa15, IKind<TF, TA16> fa16) =>
            Map16(fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8, fa9, fa10, fa11, fa12, fa13, fa14, fa15, fa16,
                (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16) =>
                    (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16));
    }
}