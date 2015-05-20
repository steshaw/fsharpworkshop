namespace Tests
open System
open NUnit.Framework
open Xunit
open Types
open Swensen.Unquote

[<TestFixture>]
type Test() = 

    [<Test>]
    member x.TestCase() =
        Console.WriteLine "Hello there"
        printf "Hi"
        printf "Hello world!\n"
        let customer = { Id = 1; IsVip = false; Credit = 0.0 }
        test <@ customer.GetType () = typeof<Customer> @>
