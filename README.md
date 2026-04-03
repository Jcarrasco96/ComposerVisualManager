# Composer Visual Manager

![License](https://img.shields.io/github/license/Jcarrasco96/ComposerVisualManager)
![Issues](https://img.shields.io/github/issues/Jcarrasco96/ComposerVisualManager)
![Platform](https://img.shields.io/badge/platform-Windows-blue)
![Built With](https://img.shields.io/badge/built%20with-.NET-purple)
![UI](https://img.shields.io/badge/UI-WinForms-blue)

## 📝 Description

Composer Visual Manager is a Windows desktop application designed to provide a visual interface for managing PHP dependencies using Composer. It simplifies dependency management by allowing developers to view, install, update, and audit packages through an intuitive graphical interface, inspired by the NuGet Package Manager in Microsoft Visual Studio and [npm-visual-manager](https://github.com/luisssc/npm-visual-manager).

## 🚀 Features

* Visual table to manage Composer dependencies (`require` and `require-dev`)
* ~~Sorting and filtering by dependency type~~
* Search and install packages from Packagist
* One-click updates (individual or bulk)
* ~~Version constraint awareness (`^`, `~`, exact versions, etc.)~~
* ~~Security audit integration~~
* ~~Deprecation warnings and package insights~~
* ~~View package changelogs and metadata~~
* ~~Ignore packages from update checks~~
* ~~Multi-project support (monorepos)~~
* Native Windows UI experience
* Fast and lightweight executable

## 📁 Project structure

```text
Models/
	ComposerLock.vb
	LockPackage.vb
	PackageData.vb
	PackageResult.vb
	PackageVersion.vb
	PackagistResponse.vb
	RequireComposerItem.vb
DialogProgressComposer.vb
FormInstall.vb
FormMain.vb
HttpRequest.vb
ItemComposer.vb
ItemPackage.vb
ModuleMain.vb
LICENSE.md          # License file
README.md           # Documentation
```

## 🔧 Requirements

* Windows 10 or higher
* PHP project with a `composer.json` file
* Composer installed and available in PATH

## 📥 Installation

* ~~Download the latest `.exe` from the releases section~~
* Clone repo and build 😁
* Run the executable (no installation required if portable)
* Ensure Composer is installed and accessible via command line

## ⚙️ Usage

### Opening a Project

* Launch the application
* Select a folder containing a `composer.json` file

### Managing Dependencies

* View installed packages and their current versions
* Automatically check for available updates
* Update packages individually or all at once

### Installing Packages

* Search packages from Packagist
* Install as production (`require`) or development (`require-dev`)

### Additional Tools

* ~~Run Composer security audit~~
* ~~View package changelogs before updating~~
* ~~Ignore specific packages from update checks~~

## 🪤 Pull requests are welcome

Contributions are welcome! Feel free to open issues or submit pull requests to improve the application.
