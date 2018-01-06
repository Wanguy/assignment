//
//  ChecklistItem.swift
//  Checklists
//
//  Created by Richard Wang on 10/20/17.
//  Copyright © 2017 Richard Wang. All rights reserved.
//

import Foundation
import UserNotifications

class ChecklistsItem: NSObject, NSCoding {
    var text = ""
    var checked = false
    var dueDate = Date()
    var shouldRemind = false
    var itemID: Int
    
    
    required init?(coder aDecoder: NSCoder) {
        text = aDecoder.decodeObject(forKey: "Text") as! String
        checked = aDecoder.decodeBool(forKey: "Checked")
        shouldRemind = aDecoder.decodeBool(forKey: "ShouldRemind")
        itemID = aDecoder.decodeInteger(forKey: "ItemId")
        dueDate = aDecoder.decodeObject(forKey: "DueDate") as! Date
        super.init()
    }
    
    override init() {
        itemID = DataModel.nextChecklistItemID()
        super.init()
    }
    
    
    func encode(with aCoder: NSCoder) {
        aCoder.encode(text, forKey: "Text")
        aCoder.encode(checked, forKey: "Checked")
        aCoder.encode(shouldRemind, forKey: "ShouldRemind")
        aCoder.encode(dueDate, forKey: "DueDate")
        aCoder.encode(itemID, forKey: "ItemID")
    }
    
    func toogleChecked() {
        checked = !checked
    }
    
    func scheduleNotification() {
        removeNotification()
        if shouldRemind && dueDate > Date() {
            // Put the text of the item in the notification
            let content = UNMutableNotificationContent()
            content.title = "Reminder"
            content.body = text
            content.sound = UNNotificationSound.default()
            // get month, day, hour and minute from dueDate
            let calender = Calendar(identifier: .gregorian)
            let components = calender.dateComponents([.month,.day,.hour,.minute], from: dueDate)
            // display detail time by UNCalendarNotificationTrigger
            let trigger = UNCalendarNotificationTrigger(dateMatching: components, repeats: false)
            /*
             Create a object of UNNotificationRequest.
             What is critical here is that we convert the ID of checklist item to "String" type and use it to determine the notification. You can use this sign to find it if you need to cancel the message later.
             */
            let request = UNNotificationRequest(identifier: "\(itemID)", content: content, trigger: trigger)
            // Add new notification to UNUserNotificationCenter
            let center = UNUserNotificationCenter.current()
            center.add(request)
            print("We should schedule a notification")
            
            
        }
    }
    
    func removeNotification() {
        let center = UNUserNotificationCenter.current()
        center.removePendingNotificationRequests(withIdentifiers: ["\(itemID)"])
    }
    
    deinit {
        removeNotification()
    }
    
}


