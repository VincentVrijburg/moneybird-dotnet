---
name: prepare-release
description: Prepare a new Moneybird.Net version by comparing the repository with the most recent release, writing a complete CHANGELOG.md entry, and updating package versions. Use when asked to prepare, bump, or ready a new release.
argument-hint: "New semantic version without a v prefix, for example 0.25.0"
---

# Prepare a release

Prepare the repository for a new release. This skill updates release metadata
only; it does not create a tag, publish a package, or create a GitHub release.

## Input

Require one new version number in `MAJOR.MINOR.PATCH` form, without a leading
`v`. If it is missing or invalid, ask the user for it before editing files.
Call the validated value `<VERSION>` in the steps below.

## Procedure

### 1. Establish the release boundary

1. Fetch tags from `origin`.
2. Use GitHub releases to identify the most recently published, non-draft
   release. Include prereleases because Moneybird.Net releases are marked as
   prereleases.
3. Confirm that its tag exists locally and has the form `vMAJOR.MINOR.PATCH`.
   Call it `<PREVIOUS_TAG>`.
4. Read the version from both `<Version>` and `<PackageVersion>` in
   `src/Moneybird.Net/Moneybird.Net.csproj`. They must match the version in
   `<PREVIOUS_TAG>`. Stop and report the inconsistency if they do not.
5. Confirm `<VERSION>` is valid semantic version syntax, differs from the
   current version, and is greater than it. Do not guess a replacement version.

Useful commands:

```bash
git fetch origin --tags
gh release list --limit 100 --json tagName,isDraft,publishedAt
git tag --list '<PREVIOUS_TAG>'
```

Do not select the previous release from the first heading in `CHANGELOG.md`
alone. The published GitHub release and its tag define the comparison boundary.

### 2. Build the complete change inventory

Inspect every change between `<PREVIOUS_TAG>` and `HEAD` using all three views:

```bash
git log --first-parent --format='%H %s' <PREVIOUS_TAG>..HEAD
git diff --name-status <PREVIOUS_TAG>..HEAD
git diff <PREVIOUS_TAG>..HEAD
```

For each pull request found in the first-parent history, inspect its title,
body, changed files, and diff with `gh pr view` and `gh pr diff`. Do not derive
the changelog from PR titles or commit subjects alone.

Create a private working inventory in which every commit and changed file is
either:

- represented by a changelog bullet; or
- explicitly classified as supporting tests, documentation for an already
  listed change, internal implementation with no separate consumer impact, or
  release-only metadata.

Cross-check the inventory against the full diff before editing the changelog.
This accounting step is mandatory and prevents missing changes when several
pull requests landed after the previous release.

### 3. Write the changelog entry

Insert the new section directly below `# Changelog` in `CHANGELOG.md`, before
the previous release:

```markdown
## <VERSION> | YYYY-MM-DD
* Concise, user-facing description of a change.
```

Use today's date in `YYYY-MM-DD` form and follow the existing changelog style.

The bullet list must:

- cover every distinct consumer-visible feature, fix, behavior change, public
  API change, and dependency update since `<PREVIOUS_TAG>`;
- consolidate implementation, tests, and related documentation into one
  meaningful bullet rather than listing files or commits;
- use present-tense, user-facing language;
- use backticks for API types, members, endpoint names, and package names where
  appropriate;
- avoid duplicate bullets and changes already released in `<PREVIOUS_TAG>`;
- exclude release mechanics and changes with no separate consumer impact.

When classification is uncertain, inspect the source and tests involved. Never
omit a change merely because its PR body or title is vague.

### 4. Update package versions

In `src/Moneybird.Net/Moneybird.Net.csproj`, set both of these properties to
the exact input version:

```xml
<Version><VERSION></Version>
<PackageVersion><VERSION></PackageVersion>
```

Do not alter dependency versions or other project properties unless they are
part of the requested release preparation.

### 5. Validate the preparation

1. Re-read the new changelog section and repeat the inventory accounting
   against `<PREVIOUS_TAG>..HEAD`.
2. Confirm the changelog contains exactly one heading for `<VERSION>`.
3. Confirm `<Version>` and `<PackageVersion>` both equal `<VERSION>`.
4. Inspect the working diff. A normal release preparation changes only
   `CHANGELOG.md` and `src/Moneybird.Net/Moneybird.Net.csproj`.
5. Run:

   ```bash
   dotnet build --configuration Release
   dotnet test --configuration Release --no-build
   dotnet pack src/Moneybird.Net/Moneybird.Net.csproj \
     --configuration Release --no-build --output /tmp/moneybird-release-check
   ```

6. Confirm the generated package filename contains `<VERSION>`, then remove the
   temporary package output.

Report the previous release used for comparison, the prepared version, the
files changed, and the changelog items. Do not tag, publish, push, commit, or
open a pull request unless the user separately asks for that action.
