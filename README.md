# About FexDwnl

This is an application to download files from FeX.

# Features

## Create patterns

User can add one or more regexps (simplified syntax - "(?i)abcdef", partial match - no need for "^...$" supported) to identify files and combine it with root folder to download the files. The folder must be accessible via CreateFile function.

## Download the file

User can specify the FeX ID or a whole URL and click Download.

FeXDwnl will fetch the file metadata, locate the appropriate regexp and download the file(s) there.

If no regexp matches, the root is designated as the user's Downloads folder.

During the download, FeXDwnl tracks the progress and the number of files

## Prefetch

User can click Fetch instead of Download to open the window that lists the files in the folder.

The window allows to check for an existing matching regexp or to create a new one and test it.

If new regexp is needed, the window also allows to add the new regexp strait from it.

It is useful when you are first download from a new source.

## Edit, save and load regexps

The application auto-loads, saves the patterns and allows to edit them.

## More

The applciation supports nested folders.

When a file is to be downloaded, the application checks is the same file (name and size) already exists, and will not re-download.

![image](https://github.com/user-attachments/assets/6de0abfa-3730-4e07-92cd-863aa5cc059d)

