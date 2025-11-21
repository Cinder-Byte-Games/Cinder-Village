# Unity-specific workflow rules that avoid pain

1. Scenes are dangerous shared state
   - Don’t have two people editing the same scene at once.
   - Even when working solo: keep big scenes mostly as collections of prefabs, not a hand-edited mess.

2. Prefab-first thinking
   - Build systems as prefabs and drop them into scenes.
   - That way, a lot of work lives in prefab diffs, not massive scene diffs.

3. Commit strategy
   - Don’t commit with the Editor open and half a scene dirty.
   - Save all scenes → save project → then commit.
   - Commit messages that mean something, for example:
     - Add basic crop growth system
     - Refactor worker assignment to ScriptableObjects

4. One “mechanical change” at a time
   - If you rename folders, move assets, or mass-adjust import settings — do that in its own commit.
   - Otherwise your diff is pure noise.

# Committing rules

Follow this flow for feature work.

1. Update local main
```bash
git fetch origin
git checkout main
git pull origin main
```

2. Create a new branch and switch to it
```bash
git checkout -b feature/my-change
```
# or: 
```bash
git switch -c feature/my-change
```

3. Make changes, then stage & commit
```bash
git add .   # or git add <files>
git commit -m "Short, descriptive message"
```

4. Push branch to remote and set upstream
```bash
git push -u origin feature/my-change
```

5. (Optional) check status and branches
```bash
git status
git branch -vv
```

6. After PR merged, cleanup locally and remotely
```bash
git checkout main
git pull origin main
git branch -d feature/my-change
git push origin --delete feature/my-change
```