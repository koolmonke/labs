import pandas as pd
import torch
from torch import nn as nn


# ## CNN Model
# 2 conv layers + 1 fc layer
class CNN(nn.Module):
    def __init__(self):
        super(CNN, self).__init__()
        self.layer1 = nn.Sequential(
            nn.Conv2d(1, 16, kernel_size=5, padding=2),
            nn.BatchNorm2d(16),
            nn.ReLU(),
            nn.MaxPool2d(2))
        self.layer2 = nn.Sequential(
            nn.Conv2d(16, 32, kernel_size=5, padding=2),
            nn.BatchNorm2d(32),
            nn.ReLU(),
            nn.MaxPool2d(2))
        self.fc = nn.Linear(7 * 7 * 32, 10)

    def forward(self, x):
        out = self.layer1(x)
        out = self.layer2(out)
        out = out.view(out.size(0), -1)
        out = self.fc(out)
        return out


class TrainDataSet(torch.utils.data.Dataset):
    def __init__(self, csv='../../docs/train.csv'):
        train_x = pd.read_csv(csv)
        train_y = train_x.label.to_numpy().tolist()
        train_x = train_x.drop('label', axis=1).to_numpy().reshape(train_x.shape[0], 1, 28, 28)
        self.datalist = train_x
        self.label_list = train_y

    def __getitem__(self, index):
        return torch.Tensor(self.datalist[index].astype(float)), self.label_list[index]

    def __len__(self):
        return self.datalist.shape[0]


class TestDataSet(torch.utils.data.Dataset):
    def __init__(self, csv='../../docs/test.csv'):
        test_x = pd.read_csv(csv)
        test_x = test_x.to_numpy().reshape(test_x.shape[0], 1, 28, 28)
        self.datalist = test_x

    def __getitem__(self, index):
        return torch.Tensor(self.datalist[index].astype(float))

    def __len__(self):
        return self.datalist.shape[0]


num_epochs = 50
batch_size = 42
learning_rate = 0.001
