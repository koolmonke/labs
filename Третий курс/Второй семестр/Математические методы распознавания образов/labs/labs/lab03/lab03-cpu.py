import pandas as pd
import torch
import torch.nn as nn
from torch.autograd import Variable

from labs.lab03 import CNN, TrainDataSet, TestDataSet, num_epochs, batch_size, learning_rate


def main():
    train_dataset = TrainDataSet()

    test_dataset = TestDataSet()

    train_loader = torch.utils.data.DataLoader(dataset=train_dataset,
                                               batch_size=batch_size,
                                               shuffle=True,
                                               num_workers=2)
    test_loader = torch.utils.data.DataLoader(dataset=test_dataset,
                                              batch_size=batch_size,
                                              shuffle=False)

    cnn = CNN()

    criterion = nn.CrossEntropyLoss()
    optimizer = torch.optim.Adam(cnn.parameters(), lr=learning_rate)

    for epoch in range(num_epochs):
        for i, (images, labels) in enumerate(train_loader):
            images = Variable(images)
            labels = Variable(labels)

            # Forward + Backward + Optimize
            optimizer.zero_grad()
            outputs = cnn(images)
            loss = criterion(outputs, labels)
            loss.backward()
            optimizer.step()
            if (i + 1) % 100 == 0:
                print(f'Epoch [{epoch + 1:d}/{num_epochs}] '
                      f'Iter [{i + 1}/{len(train_dataset) // batch_size}] '
                      f'Loss: {loss.data:.4f}')

    cnn.eval()

    ans = torch.LongTensor()

    for images in test_loader:
        images = Variable(images)
        outputs = cnn(images)
        _, predicted = torch.max(outputs.data, 1)
        ans = torch.cat((ans, predicted), 0)

    ans = ans.cpu().numpy()

    aa = pd.DataFrame(ans)
    aa.columns = ['Label']
    aa.insert(0, 'ImageId', range(1, aa.size + 1))

    aa.to_csv('../docs/result_lab03.csv', index=False)


if __name__ == '__main__':
    main()
