# 1) make sure local main is up-to-date
```
git fetch origin
git checkout main
git pull origin main 
```

# 2) create a new branch and switch to it
```
git checkout -b feature/my-change
```
# or: 
```
git switch -c feature/my-change
```

# 3) make changes, then stage & commit
```
git add .   # or git add <files>
git commit -m "Short, descriptive message"
```
# 4) push branch to remote and set upstream
```
git push -u origin feature/my-change
```
# 5) (optional) check status and branches
```
git status
git branch -vv
```
# 6) after PR merged, cleanup locally and remotely
```
git checkout main
git pull origin main
git branch -d feature/my-change
git push origin --delete feature/my-change
```