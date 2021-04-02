import pandas as pd
import torch
import torch.nn as nn
from torch.autograd import Variable

from labs.lab02 import TrainDataSet, TestDataSet, CNN, num_epochs, batch_size, learning_rate


def main():
    train_dataset = TrainDataSet()

    test_dataset = TestDataSet()

    train_loader = torch.utils.data.DataLoader(dataset=train_dataset,
                                               batch_size=batch_size,
                                               shuffle=True,
                                               num_workers=6)
    test_loader = torch.utils.data.DataLoader(dataset=test_dataset,
                                              batch_size=batch_size,
                                              shuffle=False)

    cnn = CNN()
    print(cnn.cuda())
    criterion = nn.CrossEntropyLoss()
    optimizer = torch.optim.Adam(cnn.parameters(), lr=learning_rate)

    for epoch in range(num_epochs):
        for i, (images, labels) in enumerate(train_loader):
            images = Variable(images).cuda()
            labels = Variable(labels).cuda()

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

    ans = torch.cuda.LongTensor()

    for images in test_loader:
        images = Variable(images).cuda()
        outputs = cnn(images).cuda()
        _, predicted = torch.max(outputs.data, 1)
        ans = torch.cat((ans, predicted), 0)

    ans = ans.cpu().numpy()

    aa = pd.DataFrame(ans)
    aa.columns = ['Label']
    aa.insert(0, 'ImageId', range(1, aa.size + 1))

    aa.to_csv('../../docs/result_lab02.csv', index=False)
    if input('save? ') == 'y':
        torch.save(cnn, "../../docs/model.pt")


if __name__ == '__main__':
    main()
