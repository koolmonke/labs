from pprint import pprint

from labs.Image import read_test_data, read_train_data
from labs.lab01 import docs


def main():
    train_images = list(read_train_data(docs / "train.csv"))
    db = {digit: [image for image in train_images if image.number == digit] for digit in range(10)}
    avg_area_db = {digit: sum(image.area for image in train_images) / len(train_images) for (digit, train_images) in
                   db.items()}
    pprint(avg_area_db)
    for image in read_test_data(docs / "test.csv"):
        possible_top_3_digits = sorted([(digit, image.area - avg_area) for (digit, avg_area) in avg_area_db.items()],
                                       key=lambda x: abs(x[1]))[:3]
        print(possible_top_3_digits)


if __name__ == '__main__':
    main()
