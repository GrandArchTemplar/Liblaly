using System;

namespace Liblaly.Data {
    public interface IParser<T> where T : struct {
        (string, T?) Parse((string s, T? v) input);
    }

    public abstract class SafeParser<T>: IParser<T> where T: struct {
        public (string, T?) Parse((string s, T? v) input) => SafeParse(input);

        protected abstract (string, T?) SafeParse((string s, T? v) input);
    }
    public class ParserComb<T> : SafeParser<T> where T : struct {
        private readonly IParser<T> l;
        private readonly IParser<T> r;
        public ParserComb(IParser<T> l, IParser<T> r) {
            this.l = new ParserSafe<T>(l);
            this.r = new ParserSafe<T>(r);
        }
        protected override (string, T?) SafeParse((string s, T? v) input) {
            (string s1, T? v1) t = l.Parse(input);
            return (t.v1 != null) ? r.Parse(t) : (input.s, null);
        }
    }
    public class ParserAlt<T> : SafeParser<T> where T : struct {
        private readonly IParser<T> l;
        private readonly IParser<T> r;
        public ParserAlt(IParser<T> l, IParser<T> r) {
            this.l = new ParserSafe<T>(l);
            this.r = new ParserSafe<T>(r);
        }
        protected override (string, T?) SafeParse((string s, T? v) input) {
            (string s1, T? v1) t = l.Parse(input);
            return (t.v1 != null) ? t : r.Parse(input);
        }
    }
    public class ParserWhile<T> : SafeParser<T> where T : struct {
        private readonly IParser<T> p;
        public ParserWhile(IParser<T> p) => this.p = new ParserSafe<T>(p);
        protected override (string, T?) SafeParse((string s, T? v) input) {
            (string s1, T? v1) t = p.Parse(input);
            return (t.v1 == null) ? input : Parse(t);
        }
    }



    public class ParserSkip<T> : IParser<T> where T : struct {
        private readonly Predicate<char> pred;
        public ParserSkip(Predicate<char> pred) => this.pred = pred;
        public (string, T?) Parse((string s, T? v) input) {
            return (input.s == "")
                ? (input.s, null)
                : (pred.Invoke(input.s[0])
                    ? (input.s.Substring(1), input.v)
                    : (input.s, null));
        }
    }


    public class ParserEnd<T> : IParser<T> where T : struct {
        public (string, T?) Parse((string s, T? v) input) => (input.s == "") ? input : (input.s, null);
    }

    public class ParserOk<T> : IParser<T> where T : struct {
        public (string, T?) Parse((string s, T? v) input) => input;
    }

    public class ParserSafe<T> : SafeParser<T> where T : struct {
        private readonly IParser<T> _p;
        public ParserSafe(IParser<T> p) => _p = p;
        protected  override (string, T?) SafeParse((string s, T? v) input) => (input.v == null) ? input : _p.Parse(input);
    }

}
