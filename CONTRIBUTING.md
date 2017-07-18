Thanks for your interest in contributing to F4-SMS! At present, we are not seeking contributions, but if your submission advances the project it may be considered for inclusion.

Bug reports and Issues are welcome, as are any ideas for further development.

Cheers!
#Branches
F4-SMS uses Git Flow. This means each branch has certain conventions applied to operations on it. 
* Master: Master branch is the branch all Releases are pushed to. Only make Pull Requests to Master from Develop or from a Release/ branch. Never Fast Forward Master branch - always make a new commit, even if Fast Forward is possible. Include messages from commits being merged in the commit. Every commit to Master should also be made a Release.
* Develop: This is the main development branch. Ideally this should always build successfully. A system for tests should be proposed/implemented for Pull Requests made to Develop. To implement new features, branch from Develop, build the implementation, then Pull Request back to Develop. Avoid Fast Forward on Develop. 
