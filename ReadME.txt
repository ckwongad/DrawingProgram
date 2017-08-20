How to Use:
1. Open DrawingProgram.sln with visual studio 2015
2. Press "F5"


Assumptions
1. Call create canvas will replace the existing canvas
2. max width and height of canvas = int.MaxValue - 2
3. Draw rectangle can be used to draw line
4. drawing line out of canvas is not allowed
5. drawing rectangle out of canvas is not allowed
6. fill out of canvas is not allowed
7. Commads are case-sensitive


More Tests:
1. _canvas of Comands returned from CommandParser should not be the SimpleCanvas used in initialization
2. use Moq to do behavior test for Invoker and Command
3. integrated testing