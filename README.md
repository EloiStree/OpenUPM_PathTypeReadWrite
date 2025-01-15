# OpenUMP: Path Type Read Write

I can’t stand it. Working with string paths that could represent files, folders, relative paths, or absolute paths is a nightmare. It causes bugs and clutters my code with endless `if-then` checks.  

To solve this, I created interfaces and classes for my Unity project to ensure clarity when interacting with designers. For example:  
- "I need a relative file path."  
- "I need a relative file path with an extension."  
- "I want to combine an abstract path with multiple relative folders and a file with an extension."  

You get the idea.  

This tool provides abstraction and utilities for handling file and folder paths, making it much easier to work with them. It became so useful in my project that I decided to extract it and turn it into a standalone tool.  
