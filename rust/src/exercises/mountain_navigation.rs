#[derive(Clone, Copy, Debug, PartialEq, Eq)]
enum Direction {
    North,
    East,
    West,
    South,
}

fn get_reverse(dir: &Direction) -> Direction {
    match dir {
        &Direction::North => Direction::South,
        &Direction::South => Direction::North,
        &Direction::East => Direction::West,
        &Direction::West => Direction::East,
    }
}

fn dir_reduc(arr: &[Direction]) -> Vec<Direction> {
    let mut simplified = vec![];

    for &dir in arr {
        if let Some(&last) = simplified.last() {
            if dir == get_reverse(&last) {
                simplified.pop();
                continue;
            }
        }
        simplified.push(dir);
    }

    simplified
}

#[cfg(test)]
mod tests {
    use super::{
        dir_reduc,
        Direction::{self, *},
    };

    #[test]
    fn basic() {
        let a = [North, South, South, East, West, North, West];
        assert_eq!(dir_reduc(&a), [West]);

        let a = [North, West, South, East];
        assert_eq!(dir_reduc(&a), [North, West, South, East]);

        let a = [North, West, South];
        assert_eq!(dir_reduc(&a), [North, West, South]);

        let a = [South, South, North, South];
        assert_eq!(dir_reduc(&a), [South, South]);
    }
}
