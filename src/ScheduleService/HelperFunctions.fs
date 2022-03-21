[<AutoOpen>]
module WhereIsTheBus.ScheduleService.HelperFunctions

open System

let withDigitsOnly text = text |> String.filter Char.IsDigit

let isEmpty str = String.IsNullOrEmpty str

let isNotEmpty str = not (isEmpty str)
