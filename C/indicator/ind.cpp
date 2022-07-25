#include "pch.h"
#include "ind.h"

double* get_rsi(double* value, int period)
{
    if (period < 1) {
        return NULL;
    }

    int length = sizeof(value) / sizeof(double);
    double gain_avg = 0;
    double loss_avg = 0;

    double* result = new double[length];
    double* gain = new double[length];
    double* loss = new double[length];
    double last_value;

    if (length == 0)
    {
        return result;
    }
    else
    {
        last_value = value[0];
    }

    for (int i = 0; i < length; i++)
    {
        gain[i] = (value[i] > last_value) ? value[i] - last_value : 0;
        loss[i] = (value[i] < last_value) ? last_value - value[i] : 0;
        last_value = value[i];

        int rsi = 0;
        if (i > period)
        {
            gain_avg = ((gain_avg * (period - 1)) + gain[i]) / period;
            loss_avg = ((loss_avg * (period - 1)) + loss[i]) / period;

            if (loss_avg > 0)
            {
                double rs = gain_avg / loss_avg;
                rsi = 100 - (100 / (1 + rs));
            }
            else
            {
                rsi = 100;
            }
        }

        else if (i == period)
        {
            double gain_sum = 0;
            double loss_sum = 0;

            for (int p = 1; p <= period; p++)
            {
                gain_sum += gain[p];
                loss_sum += loss[p];
            }

            gain_avg = gain_sum / period;
            loss_avg = loss_sum / period;

            rsi = (loss_avg > 0) ? 100 - (100 / (1 + (gain_avg / loss_avg))) : 100;
        }

        result[i] = rsi;
    }

    return result;
}