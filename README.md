# Back-End-Junior-Task

To evaluate your Back-end skills, please complete the task specified in this document and send us a zipped repository to an address you have received in the email. Be sure to include only the source code and exclude any executables.

## Task

Your task is to create a command-line interface (CLI) application written in C# which will download a file from a given URL using HTTP, parse it and write to standard output result of one of two commands:

`count` or `max-age`.

## `count` command

`task.exe count <url> [--age-gt <age> | --age-lt <age>]`

This command counts number of participants satisifing condition and writes it to standard output.

### Options

- `--age-gt <age>` - counts participants where age is greater than `<age>`, where `<age>` is an integer
- `--age-lt <age>` - counts participants where age is less than `<age>`, where `<age>` is an integer

### Example

`task.exe count https://fortedigital.github.io/Back-End-Junior-Task/data.json`
should write to standard output: `5`

`task.exe count https://fortedigital.github.io/Back-End-Junior-Task/data.json --age-gt 22`
should write to standard output: `2`

## `max-age` command

`task.exe max-age <url>`

This command writes a maximum age of a participant to standard output.

### Example

`task.exe max-age https://fortedigital.github.io/Back-End-Junior-Task/data.json`
should write to standard output: `24`

## Download & parse file

The file contains a list of participants in three different formats: JSON, CSV, and ZIP archive with a CSV file. Participant data model consists of following properties:

- id: integer,
- age: integer,
- name: string,
- email: string,
- workStart: date with time,
- workEnd: date with time.

You should determine file type based on content type. It can be JSON, CSV, or ZIP archive with CSV inside. Examples of files are accessible from the following URLs:

- https://fortedigital.github.io/Back-End-Junior-Task/data.json
- https://fortedigital.github.io/Back-End-Junior-Task/data.csv
- https://fortedigital.github.io/Back-End-Junior-Task/data.zip

## Errors

When the application will not be able to get a file it should write to standard output:
`Error: Cannot get file.`

When the application will not be able to process a file write to standard output:
`Error: Cannot process the file.`

When the application will not able to parse a command write to standard output:
`Error: Invalid command.`

## Remarks

Keep in mind that you might need to add support for other commands or filter options in the future. Making sure your code is extensible will be a plus.

You are free to use external packages for instance from nuget.org.

Try not to over-engineer this task. Focus on functionality rather than input validation.
