using System;
using System.Collections.Generic;
using System.Linq;

namespace Liblaly.Data {
    class UserParser : SafeParser<UserStruct> {
        protected override (string, UserStruct?) SafeParse((string s, UserStruct? v) input) =>
            new ParserComb<UserStruct>(
                new ParserComb<UserStruct>(
                    new ParserComb<UserStruct>(
                        new ParserWhile<UserStruct>(new UserNameCharParser()),
                        new ParserSkip<UserStruct>(x => x == ';')),
                    new ParserWhile<UserStruct>(new UserDigitCharParser())),
                new ParserComb<UserStruct>(
                    new ParserSkip<UserStruct>(x => x == ';'),
                    new UserBooksParser())
            ).Parse(input);
    }

    class UserBooksParser : IParser<UserStruct> {
        public (string, UserStruct?) Parse((string s, UserStruct? v) input) {
            if (input.s == "") {
                return input;
            }

            var bookNames = new List<string>(input.s.Split(';'));
            if (bookNames.Any(string.IsNullOrEmpty)) {
                return (input.s, null);
            }

            if (input.s.Any(c => Char.IsWhiteSpace(c) && c != ' ')) {
                return (input.s, null);
            }

            input.v?.User.Books.AddRange(bookNames.Select(x => new Book(x, 1)));
            return ("", input.v);
        }
    }

    internal class UserNameCharParser : IParser<UserStruct> {
        public (string, UserStruct?) Parse((string s, UserStruct? v) input)
            => (input.s == "")
                ? (input.s, null)
                : (input.s[0] == ';')
                    ? (input.s, null)
                    : (input.s.Substring(1),
                        (UserStruct?) new UserStruct(
                            new User(
                                input.v?.User.Name + input.s[0],
                                (int) input.v?.User.Deadline)));
    }

    internal class UserDigitCharParser : IParser<UserStruct> {
        public (string, UserStruct?) Parse((string s, UserStruct? v) input)
            => (input.s == "")
                ? (input.s, null)
                : (!Char.IsDigit(input.s[0]))
                    ? (input.s, null)
                    : (input.s.Substring(1),
                        (UserStruct?) new UserStruct(
                            new User(
                                input.v?.User.Name,
                                (long) input.v?.User.Deadline * 10 + (long) char.GetNumericValue(input.s[0]))
                        ));
    }

    public class BookParser : SafeParser<BookStruct> {
        protected override (string, BookStruct?) SafeParse((string s, BookStruct? v) input) =>
            new ParserComb<BookStruct>(
                new ParserComb<BookStruct>(
                    new ParserWhile<BookStruct>(
                        new BookNameCharParser()),
                    new ParserSkip<BookStruct>(x => x == ';')),
                new ParserComb<BookStruct>(
                    new ParserWhile<BookStruct>(
                        new BookDigitCharParser()),
                    new ParserEnd<BookStruct>())).Parse(input);
    }

    internal class BookNameCharParser : IParser<BookStruct> {
        public (string, BookStruct?) Parse((string s, BookStruct? v) input)
            => (input.s == "")
                ? (input.s, null)
                : (input.s[0] == ';')
                    ? (input.s, null)
                    : (input.s.Substring(1),
                        (BookStruct?) new BookStruct(
                            new Book(
                                input.v?.Book.Name + input.s[0],
                                (int) input.v?.Book.Count)));
    }

    internal class BookDigitCharParser : IParser<BookStruct> {
        public (string, BookStruct?) Parse((string s, BookStruct? v) input)
            => (input.s == "")
                ? (input.s, null)
                : (!Char.IsDigit(input.s[0]))
                    ? (input.s, null)
                    : (input.s.Substring(1),
                        (BookStruct?) new BookStruct(
                            new Book(
                                input.v?.Book.Name,
                                (int) input.v?.Book.Count * 10 + (int) Char.GetNumericValue(input.s[0]))));
    }
}