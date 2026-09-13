# Army Equipment Tracker

This is a C#/.NET console application for managing serialized equipment accountability, inspired by real-world Army supply and arms-room workflows.

## Project Overview

Army Equipment Tracker is a proof-of-concept application designed to improve the process of issuing and returning serialized equipment.

The project was inspired by my experience working in Army supply operations, where accountability is essential when equipment is issued to Soldiers and returned to the arms room.

The application demonstrates how software can track equipment status, identify who currently has an item, prevent duplicate issues, and maintain a transaction history.

> **Note:** This project is an educational proof of concept. It uses fictional demonstration data and is not an official U.S. Army system.

## Features

The current version supports:

- Add and manage equipment
- Track equipment by unique serial number
- Search for equipment by serial number
- Issue equipment to a Soldier
- Return issued equipment
- Track equipment as `IN` or `OUT`
- Prevent equipment from being issued when it is already `OUT`
- Record Soldier name, rank, and unit
- Record issue and return timestamps
- Maintain transaction history
- Validate user selections and equipment records
- Interactive console menu

## Example Workflow

```text
ARMS ROOM EQUIPMENT TRACKER

1. Add Equipment
2. View All Equipment
3. Search Equipment
4. Issue Equipment
5. Return Equipment
6. View Transaction History
7. Exit

Example equipment record:

Equipment: M4A1
Serial Number: W123456
Category: Weapon
Location: Arms Room
Status: IN
