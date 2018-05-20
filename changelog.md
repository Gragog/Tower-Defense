# This changelog shows all changes made to this project

## Unreleased
### Added
- [td-1]: added changelog.md
- [td-1]: emenies can get next target
- [td-1]: simple enemySpawner
- [td-2]: enemies move next to a target, not perfectly to the point given
- [td-3]: created Wave ScriptaleObject to store a wave
- [td-4]: added simple UI
- [td-4]: UI showing current wave
- [td-4]: UI showing enemy in wave
- [td-4]: UI showing time to next wave
- [td-5]: Turret Updates Target an looks to it
- [td-5]: Turret shoots at target when in range
- [td-5]: added EnemyFinder that has all enemies with given tag stored
- [td-5]: added Bullet prefab and Script
- [td-5]: added #SceneManager (currently only for timeScale)

### Changed
- [td-1]: renamed branch f-1 to td-1
- [td-3]: revamped the WaveSpawner to spawn individual waves
- [td-5]: AttackInterface returns true when enemy is ded

### Removed
- [td-5]: removed AttackBehavior due to MonoBehavior inheritance

[td-1]: https://github.com/Gragog/Tower-Defense/tree/td-1
[td-2]: https://github.com/Gragog/Tower-Defense/tree/td-2
[td-3]: https://github.com/Gragog/Tower-Defense/tree/td-3
[td-4]: https://github.com/Gragog/Tower-Defense/tree/td-4
[td-5]: https://github.com/Gragog/Tower-Defense/tree/td-5