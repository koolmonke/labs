from typing import Mapping, Sequence

from labs.Image import *


def calc_ideal(db: Mapping[int, Sequence[TrainImage]]):
    vec_res = np.zeros((10, 16))

    for digit, images in db.items():
        len_images = len(images)
        for image in images:
            for area, index in image.get_squares():
                vec_res[digit, index] += area / len_images
    """
    img =
        1 2 3 4 | 5 6 7 8
        1 2 3 4 | 5 6 7 8
        1 2 3 4 | 5 6 7 8
        1 2 3 4 | 5 6 7 8
        -----------------
        1 2 3 4 | 5 6 7 8
        1 2 3 4 | 5 6 7 8
        1 2 3 4 | 5 6 7 8
        1 2 3 4 | 5 6 7 8
        
    [pix > 0] * 4
    """
    return vec_res


def main():
    train_images = list(read_train_data("../../docs/train.csv"))
    train_db = {digit: [image for image in train_images if image.number == digit] for digit in range(10)}
    m = calc_ideal(train_db)
    all_ones = [list(item.get_squares()) for item in train_db[1]]
    m_cov = np.cov(m[1, :], all_ones)

    print(m_cov)


if __name__ == '__main__':
    main()
