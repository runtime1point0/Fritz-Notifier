using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FritzNotifier.Plugins
{
    public interface INotifier
    {
        string NotificationApplication { get; }

        string WebsiteOrProgramAddress { get; }

        // gets options for notification for this application with IDs and any defaults set
        List<Objects.Option> GetAllAvailableOptions();

        // subclass of OptionsControl that displays the options
        OptionsControl CreateOptionsControl(List<Objects.Option> initialValues);

        List<Objects.Notification> TestForNotifications(List<Objects.Option> options);

        void ResetLastAccessed(List<Objects.Option> options, int defaultPollingInterval);
    }
}
