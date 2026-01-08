# About FexDwnl

This is an application to download files from FeX.
Тепер і українською :)

## Locale Config / Конфігурація перекладу

FexDwnl will load in Ukrainian on Ukrainian Windows and otherwise English. You can force the Ukrainian locale if you have another Windows locale. To do this, in the file `FexDwnl.dll.config`, set the value for parameter `"ForceLocale"` to `uk-UA` as shown below.

FexDwnl запуститься українською на українській Windows та англійською у інших випадках. Українську також можна використовувати примусово. Для цього, у файлі `FexDwnl.dll.config`, виставьте значення параметру `"ForceLocale"` в `uk-UA` як показано нижче.
<img width="650" alt="image" src="https://github.com/user-attachments/assets/36d371a0-3496-41e9-a386-062df0f608a8" />

# Features

## Create patterns

User can add one or more regexps (simplified syntax - "(?i)abcdef", partial match - no need for "^...$" supported) to identify files and combine it with root folder to download the files. The folder must be accessible via CreateFile function.

## Download the file

User can specify the FeX ID or a whole URL and click Download.

FeXDwnl will fetch the file metadata, locate the appropriate regexp and download the file(s) there.

If no regexp matches any files, the root is designated as the user's Downloads folder.

If any file has a regexp match, those which do not match any pattern are skipped.

If the source is/has a folder, all subtree is analyzed and hierarchy is preserved.

During the download, FeXDwnl tracks the progress and the number of files

During the download, FexDwnl does not re-download previously downloaded files, unless their size changed.

## Prefetch

User can click Fetch instead of Download to open the window that lists the files in the folder.

The window allows to check for an existing matching regexp or to create a new one and test it.

If new regexp is needed, the window also allows to add the new regexp strait from it.

It is useful when you are downloading from a new source for the first time.

## Edit, save and load regexps

The application auto-loads, saves the patterns and allows to edit them.

![image](https://github.com/user-attachments/assets/6de0abfa-3730-4e07-92cd-863aa5cc059d)

