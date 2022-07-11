# BH-Test-Project-Junior-
Test project for Junior level

Created by: Semenov Maxim

Known issues:
-Room UI doesn't work in server mode
-Input of connected players processed on server which makes non-host clients characters move with delay and appear out of sync. This can be fixed by allowing clients process input in their own game loop (can lead to safety issues). I also wasn't sure about sync intervals on character Network Transform and Network Rigidbody components, it requires futher testing