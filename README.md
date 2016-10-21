# About
PlebCode is an esoteric programming language that is easy enough to allow any pleb to write simple code.

# Details
## Lexical atoms
***Keywords:***
* Function, EndFunction
* While, EndWhile
* If, EndIf, Else, ElseIf
* Integer, Float
* Input, Output

**Operators:**
* Arithmetical: +, -, *, /
* Relational: <, >, =, <=, >=, !=, /=, =/=

**Separators:** (, )

**Identifiers:** letter, { letter | digit }


***Constant:*** [ "-" ], (“0” | digit), { "0" | digit }, “.”, { "0" | digit },  digit |[ "-" ], digit, { "0" | digit };

## Syntax
* program = 'Function', “ ”, identifier, [“ ()”], declarations, instructions, “EndFunction”;

* declarations = {declaration};
* declaration = type, identifier;
* type = simple | composite;
* simple = “Integer” | “Float”;
* composite = “Array”, simple, “ ”, (Integer | identifier);

* instructions = {instruction};
* instruction = (simple_instruction | compound_instruction);

* simple_instruction = assignment | IO_instruction
* assignment = “Set”, identifier, ("(", expression, ")" | constant | identifier)
* constant =  nr_integer | nr_real
* nr_real = [ "-" ], digit, { "0" | digit };
* nr_integer = [ "-" ], (“0” | digit), { "0" | digit }, “.”, { "0" | digit },  digit
* expression  = operand, ("+"|"-"|"*"|"/"), operand, {("+"|"-"|"*"|"/"), operand} |  operand
* operand =  nr_integer | nr_real | identifier
* IO_instruction = ("Input" | "Output"), identifier, (identifier | expression)

* composite_instruction = if_instruction | while_instruction

* if_instruction  = "If" condition, instructions, ["Else" instructions "EndIf"]
* condition = expression, ("==" | "!=" | "<" | "<=" | ">=" | "<"), expression

* while_instruction = "While" condition instructions "EndWhile"
